using FluentAssertions;
using NUnit.Framework;

namespace Chapter2._2_4_Accountability;

public class WhenUseFlexibleStructure {
    [Test]
    public void CanAddDepartment() {
        var orgStructureFlexible = new OrgStructureFlexible();
        var organization = new Organization("acme", orgStructureFlexible);

        // act
        organization.Add(new Department("b"));

        // assert
        organization.SubUnits.Count().Should().Be(1);
    }

    [Test]
    public void CanNotAddDivision() {
        var organization = new Organization("acme", new OrgStructureFlexible());

        // act
        organization.Add(new Division("b"));

        // assert
        organization.SubUnits.Count().Should().Be(1);
    }
}

public class WhenUseStrictStructure {
    DynamicOrgStructure orgStructure;

    [SetUp]
    public void Setup() {
        orgStructure = new DynamicOrgStructure();
        orgStructure.AddRule(new DirectConnection<Organization, Department>());
        orgStructure.AddRule(new DirectConnection<Department, Division>());
    }


    [Test]
    public void CanAddDepartment() {
        var organization = new Organization("acme", orgStructure);

        // act
        organization.Add(new Department("b"));

        // assert
        organization.SubUnits.Count().Should().Be(1);
    }

    [Test]
    public void CanNotAddDivision() {
        var organization = new Organization("acme", orgStructure);

        // act
        organization.Add(new Division("b"));

        // assert
        organization.SubUnits.Count().Should().Be(0);
    }
}
