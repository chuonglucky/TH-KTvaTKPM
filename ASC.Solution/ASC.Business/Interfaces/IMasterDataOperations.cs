using ASC.Model.Models;

namespace ASC.Business.Interfaces
{
    // 6 references
    public interface IMasterDataOperations
    {
        // 4 references
        Task<List<MasterDataKey>> GetAllMasterKeysAsync();
        // 2 references
        Task<List<MasterDataKey>> GetMasterKeyByNameAsync(string name);
        // 2 references
        Task<bool> InsertMasterKeyAsync(MasterDataKey key);
        // 2 references
        Task<bool> UpdateMasterKeyAsync(string orginalPartitionKey, MasterDataKey key);
        // 3 references
        Task<List<MasterDataValue>> GetAllMasterValuesByKeyAsync(string key);
        // 2 references
        Task<List<MasterDataValue>> GetAllMasterValuesAsync();
        // 1 reference
        Task<MasterDataValue> GetMasterValueByNameAsync(string key, string name);
        // 2 references
        Task<bool> InsertMasterValueAsync(MasterDataValue value);
        // 2 references
        Task<bool> UpdateMasterValueAsync(string originalPartitionKey, string originalRowKey, MasterDataValue value);
        // 2 references
        Task<bool> UploadBulkMasterData(List<MasterDataValue> values);
    }
}