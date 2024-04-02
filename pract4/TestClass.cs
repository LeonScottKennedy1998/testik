using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract4
{
    public class TestClass
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; } 
        public string Answer3 { get; set; }
        public RightAnwser RightAnswer { get; set; }
    }
    public enum RightAnwser 
    {
        Первый = 1,
        Второй = 2,
        Третий = 3
    
    }
}
