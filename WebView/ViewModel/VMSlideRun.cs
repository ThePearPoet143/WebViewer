using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebView.ViewModel
{
    public class VMSlideRun
    {
        public List<FieldLowDetail> lstFieldLow { get; set; }
        public string ImageFolderPath { get; set; }
        public int Count { get; set; }
        public VMSlide SlideDetails { get; set; } // Include VMSlide within VMSlideRun

    }

    public class FieldLowDetail
    {
        public string ID { get; set; }
        public string Field { get; set; }
        public string SeqNum { get; set; }
        public string Nuclei { get; set; }
        public string TargetLow { get; set; }
        public string TargetHi { get; set; }
        public string xPosition { get; set; }
        public string yPosition { get; set; }


    }
}