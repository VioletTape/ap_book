namespace Chapter2._2_3_OrgStructure.WithoutTimeRange;

public class Organization : OrgUnit {

    public Organization(string name, OrgStructure orgStructure) : base(name) {
        OrgStructure = orgStructure;
    }

    public void Add(OrgUnit orgUnit) { 
        Add(orgUnit, OrgStructure);
    }

    public void SetStructure(OrgStructure newOrgStructure) {
        /*
         * конечно же тут должен быть метод с валидацией
         * о применимости новой структуры
         */
        OrgStructure = newOrgStructure;
    }
}

public class Department : OrgUnit {
    public Department(string name) : base(name) {
    }

    public void Add(OrgUnit orgUnit) { 
        Add(orgUnit, OrgStructure);
    }
}

public class Division : OrgUnit {
    public Division(string name) : base(name) {
    }

    public void Add(OrgUnit orgUnit) { 
        Add(orgUnit, OrgStructure);
    }
}

public abstract class OrgStructure {
    public abstract bool CanAdd(OrgUnit parent, OrgUnit child);
}

public class OrgStructureStrict : OrgStructure {
    public override bool CanAdd(OrgUnit parent, OrgUnit child) {
        if (parent.GetType() == typeof(Organization)
         && child.GetType() == typeof(Department)) {
            return true;
        }

        if (parent.GetType() == typeof(Department)
         && child.GetType() == typeof(Division)) {
            return true;
        }

        return false;
    }
}

public class OrgStructureFlexible : OrgStructure {
    public override bool CanAdd(OrgUnit parent, OrgUnit child) {
        if (parent.GetType() == typeof(Organization)
         && child.GetType() == typeof(Department)) {
            return true;
        }

        if (parent.GetType() == typeof(Organization)
         && child.GetType() == typeof(Division)) {
            return true;
        }

        if (parent.GetType() == typeof(Department)
         && child.GetType() == typeof(Division)) {
            return true;
        }

        return false;
    }
}