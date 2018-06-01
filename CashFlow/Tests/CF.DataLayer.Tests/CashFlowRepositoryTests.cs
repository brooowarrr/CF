using System;
using System.Linq;
using CF.DataLayer.Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CF.DataLayer.Tests
{
    [TestClass]
    public class CashFlowRepositoryTests
    {
        private ICashFlowRepository CreateRepository()
        {
            return new CashFlowRepository();
        }

        //[TestMethod]
        //public void GetItemsTest()
        //{
        //    // arrange
        //    var repository = CreateRepository();

        //    // act
        //    var items = repository.GetAllItems();

        //    // assert
        //    items.Should().NotBeNull();
        //    items.Count.Should().BeGreaterThan(20);
        //}

        //[TestMethod]
        //public void GetCategoriesTest()
        //{
        //    // arrange
        //    var repository = CreateRepository();

        //    // act
        //    var items = repository.GetAllCategories();

        //    // assert
        //    items.Should().NotBeNull();
        //    items.Count.Should().BeGreaterThan(7);
        //}

        //[TestMethod]
        //public void GetTransactionsTest()
        //{
        //    // arrange
        //    var repository = CreateRepository();

        //    // act
        //    var items = repository.GetAllTransactions();

        //    // assert
        //    items.Should().NotBeNull();
        //    items.Count.Should().BeGreaterThan(2);
        //}

        [TestMethod]
        public void ItemsFullTest()
        {
            // arrange
            var repository = CreateRepository();

            // act
            var items = repository.GetAllItems();

            // assert
            items.Should().NotBeNull();
            items.Count.Should().BeGreaterThan(20);

            var initialCount = items.Count;

            items.Should().NotContain(x => x.Name == "Product");

            var item = new Item() {Name = "Product"};
            item.Id.Should().Be(0);
            repository.Add(item);
            item.Id.Should().BeGreaterThan(0);

            var addedItemId = item.Id;


            items = repository.GetAllItems();
            items.Should().NotBeNull();
            items.Count.Should().Be(initialCount+1);
            items.Should().Contain(x => x.Name == "Product");

            item.Name = "Product Updated";
            repository.Edit(item);
            items = repository.GetAllItems();
            items.Should().NotBeNull();
            items.Count.Should().Be(initialCount + 1);
            items.Should().NotContain(x => x.Name == "Product");
            items.Should().Contain(x => x.Name == "Product Updated");
            item = items.First(x => x.Name == "Product Updated");
            item.Id.Should().Be(addedItemId);

            repository.Remove(item);

            items = repository.GetAllItems();
            items.Should().NotBeNull();
            items.Count.Should().Be(initialCount);
            items.Should().NotContain(x => x.Name == "Product Updated");

        }

        [TestMethod]
        public void CategoriesFullTest()
        {
            var repository = CreateRepository();
            var categories = repository.GetAllCategories();
            categories.Should().NotBeNull();
            categories.Count.Should().BeGreaterThan(5);

            var initialCount = categories.Count;

            categories.Should().NotContain(x => x.Name == "Holiday");

            var category = new Category() { Name = "Holiday" };
            category.Id.Should().Be(0);
            repository.Add(category);
            category.Id.Should().BeGreaterThan(0);

            var addedCategoryId = category.Id;


            categories = repository.GetAllCategories();
            categories.Should().NotBeNull();
            categories.Count.Should().Be(initialCount + 1);
            categories.Should().Contain(x => x.Name == "Holiday");

            category.Name = "Holiday Updated";
            repository.Edit(category);
            categories = repository.GetAllCategories();
            categories.Should().NotBeNull();
            categories.Count.Should().Be(initialCount + 1);
            categories.Should().NotContain(x => x.Name == "Holiday");
            categories.Should().Contain(x => x.Name == "Holiday Updated");
            category = categories.First(x => x.Name == "Holiday Updated");
            category.Id.Should().Be(addedCategoryId);

            repository.Remove(category);

            categories = repository.GetAllCategories();
            categories.Should().NotBeNull();
            categories.Count.Should().Be(initialCount);
            categories.Should().NotContain(x => x.Name == "Holiday Updated");

        }

        [TestMethod]
        public void CategoriesDefinitionsFullTest()
        {
            var repository = CreateRepository();
            var categories = repository.GetAllCategories();
            categories.Should().NotBeNull();
            categories.Count.Should().BeGreaterThan(5);
            var initialCategoriesCount = categories.Count;

            categories.Should().Contain(x => x.Name == "Accommodation");
            var category = categories.First(x => x.Name == "Accommodation");
            var categoryDefinition = repository.GetCategoryDefinition(category);
            categoryDefinition.Should().NotBeNull();
            categoryDefinition.Category.Id.Should().BeGreaterThan(0);
            categoryDefinition.Category.Name.Should().Be("Accommodation");
            categoryDefinition.Items.Count.Should().BeGreaterThan(0);
            categoryDefinition.Items.First().Id.Should().BeGreaterThan(0);


            categories.Should().NotContain(x => x.Name == "Holiday");

            category = new Category() { Name = "Holiday" };
            category.Id.Should().Be(0);
            repository.Add(category);
            category.Id.Should().BeGreaterThan(0);

            var addedCategoryId = category.Id;

            categoryDefinition = repository.GetCategoryDefinition(category);
            categoryDefinition.Items.Count.Should().Be(0);

            var items = repository.GetAllItems();

            items.Should().NotBeNull();
            items.Count.Should().BeGreaterThan(20);

            var initialItemsCount = items.Count;

            var item1 = new Item() { Name = "Flight" };
            repository.Add(item1);
            var item2 = new Item() { Name = "Hotel" };
            repository.Add(item2);

            categoryDefinition.Items.Add(item1);
            categoryDefinition.Items.Add(item2);

            repository.Edit(categoryDefinition);

            categoryDefinition = repository.GetCategoryDefinition(category);
            categoryDefinition.Items.Count.Should().Be(2);
            categoryDefinition.Items.Should().Contain(x => x.Name == "Flight");
            categoryDefinition.Items.Should().Contain(x => x.Name == "Hotel");

            repository.Remove(categoryDefinition);
            categoryDefinition = repository.GetCategoryDefinition(category);
            categoryDefinition.Items.Count.Should().Be(0);

            repository.Remove(category);


            categories = repository.GetAllCategories();
            categories.Should().NotBeNull();
            categories.Count.Should().Be(initialCategoriesCount);
            categories.Should().NotContain(x => x.Name == "Holiday");

            repository.Remove(item1);
            repository.Remove(item2);

            items = repository.GetAllItems();
            items.Should().NotBeNull();
            items.Count.Should().Be(initialItemsCount);
            items.Should().NotContain(x => x.Name == "Flight");
            items.Should().NotContain(x => x.Name == "Hotel");

        }

        [TestMethod]
        public void TransactionsFullTest()
        {


        }
    }
}
