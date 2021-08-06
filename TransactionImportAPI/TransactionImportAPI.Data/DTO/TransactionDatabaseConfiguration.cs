namespace TransactionImportAPI.Data.DTO
{
    public class TransactionDatabaseConfiguration
    {
        public string TransactionCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}