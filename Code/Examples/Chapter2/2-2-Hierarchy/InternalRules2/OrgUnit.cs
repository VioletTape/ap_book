namespace Chapter2._2_2_Hierarchy.InternalRules2;

public abstract class OrgUnit {
    private List<OrgUnit> childs = new List<OrgUnit>();

    public string Name { get; init; }

    public List<OrgUnit> SubUnits => [..childs];
    
    protected OrgUnit(string name) {
        Name = name;
    }

    public static void Add(OrgUnit parent, OrgUnit child) {
        if (parent.GetType() == typeof(Organization)
            && child.GetType() == typeof(Department)) {
            parent.childs.Add(child);
        }

        if (parent.GetType() == typeof(Department)
            && child.GetType() == typeof(Division)) {
            parent.childs.Add(child);
        }
    }
}