using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Linq;

namespace AcsugDemo.FunctionApp.Services
{
    public class DuplicateCheckService
    {
        public class DuplicateEntity : TableEntity
        {
            public string MessageType { get; set; }
            public string DuplicateKey { get; set; }
        }

        internal readonly CloudStorageAccount storageAccount;
        internal readonly CloudTableClient tableClient;
        internal readonly CloudTable cloudTable;
        private const string tableName = "DuplicateKeyStore";

        public DuplicateCheckService()
        {
            storageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("StorageAccountConnectionString"));
            tableClient = storageAccount.CreateCloudTableClient();            
            cloudTable = tableClient.GetTableReference(tableName);
        }

        /// <summary>
        /// Given a message type and duplicate key, check to see if they exist on duplicate key store.
        /// Found no duplicate, add the DuplicateKey to the key store.
        /// </summary>       
        public bool PerformDuplicateCheck(string messageType, string duplicateKey)
        {
            var duplicateEntity = new DuplicateEntity { PartitionKey = messageType, RowKey = duplicateKey };

            var tableQueryResult = cloudTable.CreateQuery<DuplicateEntity>()
                            .Where(d => d.PartitionKey == messageType && d.RowKey == duplicateKey)
                            .ToList();

            if (tableQueryResult.Count > 0)
            {
                return true;
            }
            else
            {
                cloudTable.Execute(TableOperation.Insert(duplicateEntity));
                return false;
            }
        }

    }
}
