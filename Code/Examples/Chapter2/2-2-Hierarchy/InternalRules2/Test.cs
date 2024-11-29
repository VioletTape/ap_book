namespace Chapter2._2_2_Hierarchy.InternalRules2;

public class Test {
    public void CanAdd() {
        var organization = new Organization("a");
        var department = new Department("b");

        OrgUnit.Add(organization,department);


    }
}