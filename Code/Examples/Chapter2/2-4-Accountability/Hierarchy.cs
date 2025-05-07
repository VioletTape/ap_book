using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Chapter2._2_4_Accountability;

/*******************************************
 * Главные изменения
 *******************************************/

// Шаблон для определения типа и правил для организационной структуры
public abstract class OrgStructure {

    // структура организации, согласно диаграмме,
    // имеет период когда она актуальна
    public Period EffectivePeriod { get; init; }
    
    protected OrgStructure() {
        EffectivePeriod = new Period(new DateOnly(2025, 1, 1), null);
    }
    
    // заранее ничего не знаем о правилах добавления 
    // и отдаем это на откуп конкретным правилам 
    public abstract bool CanAdd(OrgUnit parent, OrgUnit child);


    public void Close() {
        EffectivePeriod.Close();
    }
}

public class DynamicOrgStructure : OrgStructure {
    Dictionary<Type, OrgRule> orgRules;

    public DynamicOrgStructure() {
        orgRules = new Dictionary<Type, OrgRule>();
    }

    public override bool CanAdd(OrgUnit parent, OrgUnit child) {
        return orgRules.Where(t => t.Key == parent.GetType())
                .Select(t => t.Value)
                .All(r => r.IsSatisfy(parent, child));


    }

    public void AddRule(OrgRule rule) {
        orgRules.Add(rule.OriginType, rule);
    }
}

public abstract class OrgRule {
    protected Type unit;

    public Type OriginType => unit;

    protected OrgRule() {
       
    }

    public abstract bool IsSatisfy(OrgUnit parentUnit, OrgUnit childUnit);
}

public class MainOrgLimitations : OrgRule {
    public MainOrgLimitations()  {
       unit = typeof(Organization);
    }

    public override bool IsSatisfy(OrgUnit parentUnit, OrgUnit childUnit) {
        return true;
    }
}

public abstract class ConnectionRule<P, C> : OrgRule
    where P : OrgUnit
    where C : OrgUnit { }

public class DirectConnection<P, C> : ConnectionRule<P, C>
    where P : OrgUnit
    where C : OrgUnit 
{
    Type parentType;
    Type childType;

    public DirectConnection() {
        unit = typeof(P);
        parentType = typeof(P);
        childType = typeof(C);
    }

    public override bool IsSatisfy(OrgUnit parentUnit, OrgUnit childUnit) {
        return parentUnit.GetType().IsAssignableTo(parentType)
            && childUnit.GetType().IsAssignableTo(childType);
    }
}


/// <summary>
/// Конкретная реализация типа и правил для организационной структуры.
/// В данном случае, свободная иерархия отделов. 
/// </summary>
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





/*******************************************
 * Остальное
 *******************************************/

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





public record Period(DateOnly start, DateOnly? end) {
      /*
       * тут всякие проверки на корректность периода и
       * связанные методы
       */

      // ... 

      public void Close() {
      }
}