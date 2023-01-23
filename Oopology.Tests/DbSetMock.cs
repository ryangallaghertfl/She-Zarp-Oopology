using Oopology.Models;

namespace Oopology.Tests
{
    internal class DbSetMock<T>
    {
        private List<Purchase> purchases;
        private List<User> users;

        public DbSetMock(List<Purchase> purchases)
        {
            this.purchases = purchases;
        }

        public DbSetMock(List<User> users)
        {
            this.users = users;
        }

        public DbSetMock()
        {

        }
    }
}