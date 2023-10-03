using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_Competition.DataModel
{
   public class AddCertificateDataModel
    {
        public string CertificateName { get;set;}
        public string CertifiedBody { get;set;}

        public string year { get;set;}

    }
    public class CertificationList
    {
        private List<AddCertificateDataModel> addcertifications;
        public List <AddCertificateDataModel> AddCertifications { get=> addcertifications; set=> addcertifications = value; }
    }
}
