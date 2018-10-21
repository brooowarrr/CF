using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace CF.DataLayer.Dapper
{
    public class CashFlowRepository : ICashFlowRepository
    {
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["CashFlowDB"].ConnectionString);

        public List<Item> GetAllItems()
        {
            return this.db.Query<Item>("SELECT * FROM Items").ToList();
        }

        public bool Add(Item item)
        {
            var sql =
                "INSERT INTO Items (Name) VALUES(@Name); " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            item.Id = this.db.Query<int>(sql, item).Single();
            return true;
        }

        public bool Edit(Item item)
        {
            var sql =
                "UPDATE Items " +
                "SET Name = @Name " +
                "WHERE Id = @Id";
            this.db.Execute(sql, item);
            return true;
        }

        public bool Remove(Item item)
        {
            var affected = this.db.Execute("DELETE FROM Items WHERE Id = @Id", new { item.Id });
            return true;
        }

        public List<Category> GetAllCategories()
        {
            return this.db.Query<Category>("SELECT * FROM Categories").ToList();
        }

        public bool Add(Category category)
        {
            var sql =
                "INSERT INTO Categories (Name) VALUES(@Name); " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            category.Id = this.db.Query<int>(sql, category).Single();
            return true;
        }

        public bool Edit(Category category)
        {
            var sql =
                "UPDATE Categories " +
                "SET Name = @Name " +
                "WHERE Id = @Id";
            this.db.Execute(sql, category);
            return true;
        }

        public bool Remove(Category category)
        {
            RemoveFromCategoryDefinitions(category.Id);
            this.db.Execute("DELETE FROM Categories WHERE Id = @Id", new { category.Id });
            return true;
        }

        public CategoryDefinition GetCategoryDefinition(Category category)
        {
            var sql=
            "SELECT i.Id , i.Name  " +
            "FROM CategoriesDefinitions d " +
            "LEFT JOIN [CashFlowDB].[dbo].Items i on i.Id = d.ItemId " +
            "LEFT JOIN [CashFlowDB].[dbo].Categories c on c.Id = d.CategoryId " +
            "WHERE CategoryId = @categoryId";

            var items = this.db.Query<Item>(sql, new { categoryId = category.Id }).ToList();

            return new CategoryDefinition() {Category = category, Items = items};
        }

        public bool Add(CategoryDefinition definition)
        {
            var sql =
                "INSERT INTO CategoriesDefinitions (CategoryId, ItemId) VALUES(@CategoryId, @ItemId); " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            definition.Items.ForEach(item => this.db.Execute(sql, new { CategoryId = definition.Category.Id, ItemId = item.Id }));
            return true;
        }

        public bool Edit(CategoryDefinition definition)
        {
            Remove(definition);
            Add(definition);
            return true;
        }

        public bool Remove(CategoryDefinition definition)
        {
            return RemoveFromCategoryDefinitions(definition.Category.Id);
        }

        private bool RemoveFromCategoryDefinitions(int categoryId)
        {
            this.db.Execute("DELETE FROM CategoriesDefinitions WHERE CategoryId = @CategoryId", new { CategoryId = categoryId });
            return true;
        }

        public List<Transaction> GetAllTransactions()
        {
            return this.db.Query<Transaction>("SELECT * FROM Transactions").ToList();
        }

        public List<Transaction> GetAllPendingTransactions()
        {
            return this.db.Query<Transaction>("SELECT * FROM Transactions WHERE IsPending=1").ToList();
        }

        public bool FinishPendingTransaction(int transactionId)
        {
            var dateModified = DateTime.Now;
            var sql =
                "UPDATE Transactions " +
                "SET " +
                "DateModified = @DateModified " +
                "IsPending = 0 " +
                "WHERE Id = @Id";
            this.db.Execute(sql, dateModified);
            return true;
        }

        public bool Add(Transaction transaction)
        {
            transaction.DateCreated = DateTime.Now;
            transaction.DateModified = transaction.DateCreated;
            var sql =
                "INSERT INTO Transactions (Value, SourceItemId, TargetItemId, Description, DateCreated, DateModified, IsPending) " +
                "VALUES(@Value, @SourceItemId, @TargetItemId, @Description, @DateCreated, @DateModified, @DateModified, @IsPending); " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            transaction.Id = this.db.Query<int>(sql, transaction).Single();
            return true;
        }

        public bool Edit(Transaction transaction)
        {
            transaction.DateModified = DateTime.Now;
            var sql =
                "UPDATE Transactions " +
                "SET Value = @Value, " +
                "SourceItemId = @SourceItemId, " +
                "TargetItemId = @TargetItemId, " +
                "Description = @Description, " +
                "DateCreated = @DateCreated, " +
                "DateModified = @DateModified " +
                "IsPending = @IsPending " +
                "WHERE Id = @Id";
            this.db.Execute(sql, transaction);
            return true;
        }

        public bool Remove(Transaction transaction)
        {
            this.db.Execute("DELETE FROM Transactions WHERE Id = @Id", new { transaction.Id });
            return true;
        }

        public List<Item> GetAssetsConfiguration()
        {
            var sql =
                "SELECT i.Id , i.Name  " +
                "FROM [AssetsConfig] a " +
                "LEFT JOIN [CashFlowDB].[dbo].Items i on a.ItemId = i.Id";

            return this.db.Query<Item>(sql).ToList();
        }
    }
}
