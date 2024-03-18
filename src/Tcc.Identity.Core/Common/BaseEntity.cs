using System.ComponentModel.DataAnnotations;

namespace Tcc.Identity.Core.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
