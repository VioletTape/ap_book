using FluentAssertions;
using NUnit.Framework;

namespace Chapter2._2_2_Hierarchy.InternalRules;

public class Test {
    [Test]
    public void CanAddDepartment() {
        var organization = new Organization("a");
        var department = new Department("b");

        // act
        organization.Add(department);

        // assert
        organization.SubUnits.Should().Contain(department);
    }

    [Test]
    public void CanAddDivision() {
        var department = new Department("b");
        var division = new Division("c");

        // act
        department.Add(division);

        // assert
        department.SubUnits.Should().Contain(division);
    }

    [Test]
    public void CanNotAddDivision() {
        var division1 = new Division("c");
        var division2 = new Division("d");

        // act
        division1.Add(division2);
        
        // assert
        division1.SubUnits.Should().NotContain(division2);
    }
}
