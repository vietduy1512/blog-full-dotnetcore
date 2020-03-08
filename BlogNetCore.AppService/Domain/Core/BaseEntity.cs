using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogNetCore.AppService.Domain.Core
{
    public abstract class BaseEntity<TId>
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public virtual TId Id { get; set; }
    }
}
