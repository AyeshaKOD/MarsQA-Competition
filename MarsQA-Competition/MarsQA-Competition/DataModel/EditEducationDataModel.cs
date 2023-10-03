using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MarsQA_Competition.DataModel
{
    public class EditEducationDataModel
    {
        public string CollegeNameToUpdate { get; set; }
        public string NewCollegeName { get; set; }
        //public string CountryToUpdate { get; set; }
        public string NewCountry { get; set; }
       // public string TitleToUpdate { get; set; }
        public string NewTitle { get; set; }
        //public string DegreeNameToUpdate { get; set; }
        public string NewDegreeName { get; set; }
       // public string YearGraduationToUpdate { get; set; }
        public string NewYearGraduation { get; set; }

    }
    //public class EditEducationList
    //{
    //    private List<EditEducationDataModel> updateeducations;
    //    public List<EditEducationDataModel> UpdateEducations { get => updateeducations; set => updateeducations = value; }

    //}

}



