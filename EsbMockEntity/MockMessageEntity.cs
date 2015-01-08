using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockEntity
{    
    public class MockMessageEntity : DbContext
    {
        public void m()
        {
            this.MockMessages.Include(e => e.RequestType);
        }
        public DbSet<ServiceTypeInfo> ServiceTypes { get; set; }
        public DbSet<MockMessage> MockMessages { get; set; }
        public DbSet<RequestTypeInfo> RequestTypeInfos { get; set; }
    }

    public class ServiceTypeInfo
    {
        public string WSName { get; set; }
        public string WsUrl {get;set;}
        [Key]
        public string WebServiceId {get;set;}
    }

    public class RequestTypeInfo
    {
        [Key]
        public string RequestType { get; set; }
        public ServiceTypeInfo ServiceType { get; set; }
    }

    public class MockMessage
    {
        //public int Id { get; set; }
        [Key]
        public string KeyInfo { get; set; }
        public RequestTypeInfo RequestType { get; set; }
        public string RequestXml { get; set; }
        public string ResponseXml { get; set; }
        public DateTime InTime { get; set; }
        public DateTime LastModifyTime { get; set; }
        public string Comment { get; set; }
        public TimeSpan Timeout { get; set; }
    }

    public class SampleMessage
    {
        public string RequestXml { get; set; }
        public string ResponseXml { get; set; }
        public string Comment { get; set; }
        public string WebServiceId { get; set; }
        public string TimeOut { get; set; }
    }

    public class PutMessageWithRes
    {
        public string RequestXml { get; set; }
        public string ResponseXml { get; set; }
        public string WebServiceId { get; set; }
    }

    public class PutMessageWithComment
    {
        public string RequestXml { get; set; }
        public string Comment { get; set; }
        public string WebServiceId { get; set; }
    }

    public class MessageWithTimeOut
    {
        public string RequestXml { get; set; }
        public string WebServiceId { get; set; }
        public TimeSpan Timeout { get; set; }
    }
}
