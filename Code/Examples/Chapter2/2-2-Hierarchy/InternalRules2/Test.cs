﻿using FluentAssertions;
using NUnit.Framework;

namespace Chapter2._2_2_Hierarchy.InternalRules2;

// простые тесты для иллюстративности
public class Test {
    [Test]
    public void CanAddDepartment() {
        var organization = new Organization("a");
        var department = new Department("b");

        // act
        OrgUnit.Add(organization,department);

        // assert
        organization.SubUnits.Should().Contain(department);
    }

    [Test]
    public void CanAddDivision() {
        var department = new Department("b");
        var division = new Division("c");

        // act
        OrgUnit.Add(department,division);

        // assert
        department.SubUnits.Should().Contain(division);
    }

    [Test]
    public void CanNotAddDivision() {
        var division1 = new Division("c");
        var division2 = new Division("d");

        // act
        OrgUnit.Add(division1,division2);

        // assert
        division1.SubUnits.Should().NotContain(division2);
    }
}