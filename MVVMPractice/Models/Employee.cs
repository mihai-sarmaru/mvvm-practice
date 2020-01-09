using System;

namespace MVVMPractice.Models {
    public class Employee {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public int Experience { get; set; }

        public Employee() {
            ID = Guid.NewGuid().ToString();
        }
    }
}
