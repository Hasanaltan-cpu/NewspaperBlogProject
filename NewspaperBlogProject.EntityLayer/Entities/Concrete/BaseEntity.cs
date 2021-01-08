using NewspaperBlogProject.EntityLayer.Entities.Interface;
using NewspaperBlogProject.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperBlogProject.EntityLayer.Entities.Concrete
{
    public class BaseEntity : IBaseEntity<int>
    {
      
        public int Id { get ; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }


        private Status _status = Status.Active;
        public Status Status { get=>_status; set=>_status=value;}
    }
}

