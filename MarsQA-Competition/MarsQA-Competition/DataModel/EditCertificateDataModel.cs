using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_Competition.DataModel
{
    public  class EditCertificateDataModel
    {
        public string CertificateNameToUpdate { get; set; }
        public string CertificateName { get; set; }
        public string CertifiedBody { get; set; }

        public string Year { get; set; }
    }
    //public class UpdateCetificateList
    //{
    //    private List<EditCertificateDataModel> updatecertifications;
    //    public List<EditCertificateDataModel> UpdateCertifications { get=> updatecertifications; set=> updatecertifications = value; }
    //}
}
