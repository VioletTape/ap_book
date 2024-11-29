namespace Chapter2._2_2_Hierarchy.NoRules;

public class Organization : OrgUnit {
    public Organization(string name) : base(name) {
    }
}

public class Department : OrgUnit {
    public Department(string name) : base(name) {
    }
}

public class Division : OrgUnit {
    public Division(string name) : base(name) {
    }
}