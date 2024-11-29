namespace Chapter2._2_2_Hierarchy.NoRules;

public abstract class OrgUnit {
    private List<OrgUnit> childs = new List<OrgUnit>();

    public string Name { get; init; }

    protected OrgUnit(string name) {
        Name = name;
    }

    public void Add(OrgUnit orgUnit) {
        childs.Add(orgUnit);
    }
}