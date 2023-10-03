using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_Competition.DataModel
{
    public class EducationDataModel
    {
       
        public string CollegeName { get; set; }
        public string Country { get; set; }
        public string Title { get; set; }
        public string DegreeName { get; set; }
        public int YearGraduation { get; set; }
        

    }
    public class EducationsList
    {

        private List<EducationDataModel> educations;
        public List<EducationDataModel> Educations { get => educations; set => educations = value; }
    }
    //public class DeleteEducation
    //{
        
    //}
    //private List<EducationDataModel> updateeducations;
    // public List<EducationDataModel> UpdateEducations { get => updateeducations; set => updateeducations = value; }

    //}
}
