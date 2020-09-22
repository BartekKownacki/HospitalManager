using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HospitalManager.Domain.Common
{
    public class AuditableModel
    {
        [XmlElement("Doctor ID")]
        public int CreatedById { get; set; }
        [XmlIgnore]
        public DateTime CreatedDateTime { get; set; }
        [XmlIgnore]
        public int? ModifiedById{ get; set; }
        [XmlIgnore]
        public DateTime? ModifiedDateTime { get; set; }
    }
}
