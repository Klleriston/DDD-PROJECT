using Entities.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Table("TB_NEWS")]
    public class News : Notifie
    {
        [Column("NS_ID")]
        public int Id { get; set; }
        [Column("NS_TITLE")]
        [MaxLength(255)]
        public string Title { get; set; }
        [Column("NS_INFO")]
        [MaxLength(255)]
        public string Info { get; set; }
        [Column("NS_ACTIVE")]
        public bool Active { get; set; }
        [Column("NS_SINGUP_DATE")]
        public DateTime SingUp { get; set; }
        [Column("NS_UPDATE_DATE")]
        public DateTime UpdateDate { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
