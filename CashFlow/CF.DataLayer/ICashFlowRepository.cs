using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.DataLayer
{
    public interface ICashFlowRepository
    {       
        List<Item> GetAllItems();
        bool Add(Item item);
        bool Edit(Item item);
        bool Remove(Item item);

        List<Category> GetAllCategories();
        bool Add(Category category);
        bool Edit(Category category);
        bool Remove(Category category);

        CategoryDefinition GetCategoryDefinition(Category category);
        bool Add(CategoryDefinition definition);    
        bool Edit(CategoryDefinition definition);
        bool Remove(CategoryDefinition definition);

        List<Transaction> GetAllPendingTransactions();
        bool FinishPendingTransaction(int transactionId);

        List<Transaction> GetAllTransactions();
        //List<Transaction> GetTransactionsByCategory(int categoryId);
        //List<Transaction> GetTransactionsByDate(DateTime from, Datetime to);
        bool Add(Transaction transaction);
        bool Edit(Transaction transaction);
        bool Remove(Transaction transaction);

        List<Item> GetAssetsConfiguration();
    }

    //transakcje mozna wykonywac tylko z lub do Item ktory jest w assetsConfig
    // na poczatek stan danych itemow wyliczany, pozniej moglby byc datowany na jakis dzien po kazdej transakcji
}
