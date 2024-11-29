namespace Chapter2._2_1_Party {
    public class Address {
        public Country Country { get; set; }
        public string PostCode { get; set; }
        public string Street { get; set; }
        
        // ...
    }

    public class Email {

    }

    public class Phone {
        public PhoneType Type { get; init; }
        
        public CountryCode Code { get; init; }

        public string PhoneNumber { get; set; }

        // .. 
    }

    // Для наглядности оставлено Party, 
    // но в реальном проекте назвал бы 
    // OrgUnit или ContactEntry
    public class Party {
        public Address Address { get; set; }
        public Email Email { get; set; }
        public Phone Phone { get; set; }

        // ...
    }

    public class Organization : Party {
        // ...
    }

    public class Person : Party {
        // ...
    }
}
