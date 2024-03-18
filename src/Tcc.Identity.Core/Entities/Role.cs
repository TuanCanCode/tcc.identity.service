using Tcc.Identity.Core.Common;

namespace Tcc.Identity.Core.Entities
{
#nullable disable
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
