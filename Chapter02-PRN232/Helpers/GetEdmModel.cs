using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Chapter02_PRN232.Helpers
{
    public class GetEdmModel
    {
        public static IEdmModel GetModel()
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<BusinessObjects.Gadgets>("Gadgets");
            return modelBuilder.GetEdmModel();
        }
    }
}
