namespace Chapter2._2_2_Hierarchy.InternalRules;

public class Organization : OrgUnit {
    public Organization(string name) : base(name) {
    }

    internal override bool CanAdd(OrgUnit orgUnit) {
        return orgUnit.GetType() == typeof(Department);
    }
}

public class Department : OrgUnit {
    public Department(string name) : base(name) {
    }

    internal override bool CanAdd(OrgUnit orgUnit) {
        return orgUnit.GetType() == typeof(Division);
    }
}

public class Division : OrgUnit {
    public Division(string name) : base(name) {
    }
    internal override bool CanAdd(OrgUnit orgUnit) {
        return false;
    }
}