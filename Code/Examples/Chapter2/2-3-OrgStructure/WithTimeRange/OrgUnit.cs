namespace Chapter2._2_3_OrgStructure.WithTimeRange;

public abstract class OrgUnit {
    protected OrgStructure OrgStructure;
    private List<OrgUnit> childs = new List<OrgUnit>();

    public string Name { get; init; }

    public List<OrgUnit> SubUnits => [..childs];

    protected OrgUnit(string name) {
        Name = name;
    }

    protected void Add(OrgUnit orgUnit, OrgStructure orgStructure) {
        if (OrgStructure.CanAdd(this, orgUnit)) {
            orgUnit.OrgStructure = orgStructure;
            childs.Add(orgUnit);
        }
    }
}