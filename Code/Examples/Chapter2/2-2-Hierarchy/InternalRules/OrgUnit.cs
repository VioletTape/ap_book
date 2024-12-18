namespace Chapter2._2_2_Hierarchy.InternalRules;

public abstract class OrgUnit {
    private List<OrgUnit> childs = new List<OrgUnit>();

    public string Name { get; init; }

    public List<OrgUnit> SubUnits => [..childs];

    public OrgUnit(string name) {
        Name = name;
    }

    public void Add(OrgUnit orgUnit) {
        if (CanAdd(orgUnit)) {
            childs.Add(orgUnit);
        }
    }

    internal abstract bool CanAdd(OrgUnit orgUnit);
}