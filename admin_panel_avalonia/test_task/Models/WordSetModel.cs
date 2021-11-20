using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_task.Models
{
    public class WordSetModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int id { get; set; }
        public int creator_id { get; set; }
        public int lang_id { get; set; }
        public int title { get; set; }

        public int id { get; set; }
        public int creator_id {get;set;}
        public int lang_id { get; set; }
        public int title{ get; set; }
    }
}
