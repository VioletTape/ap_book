namespace Chapter2._2_3_OrgStructure.WithTimeRange;

public class Organization : OrgUnit {
    Dictionary<Period, OrgStructure> history = new Dictionary<Period, OrgStructure>();

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
        OrgStructure.Close();
        history.Add(OrgStructure.EffectivePeriod, OrgStructure);
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

    public Period EffectivePeriod { get; init; }
    
    protected OrgStructure() {
    }

    public abstract bool CanAdd(OrgUnit parent, OrgUnit child);


    public void Close() {
        EffectivePeriod.Close()
    }
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

public record Period(DateOnly start, DateOnly? end) {
      /*
       * тут всякие проверки на корректность периода и
       * связанные методы
       */

      // ... 

      public void Close() {
      }
}