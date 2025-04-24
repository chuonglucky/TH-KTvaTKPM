namespace ASC.Web.Areas.Configuration.Models
{
    // 4 references
    public class MasterValuesViewModel
    {
        // 1 reference
        public List<MasterDataValueViewModel> ? MasterValues { get; set; }
        // 8 references
        public MasterDataValueViewModel MasterValueInContext { get; set; }
        // 2 references
        public bool IsEdit { get; set; }
    }
}