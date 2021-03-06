namespace Open311.GeoReportApi.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [CollectionDataContract(
        Name = Open311Constants.ModelProperties.Services, 
        ItemName = Open311Constants.ModelProperties.Service,
        Namespace = Open311Constants.DefaultNamespace)]
    public class Services : List<Service>
    {
        public Services()
        {
        }

        public Services(int capacity)
            : base(capacity)
        {
        }

        public Services(IEnumerable<Service> services)
            : base(services)
        {
        }

        public Services(params Service[] services)
            : base(services)
        {
        }
    }
}