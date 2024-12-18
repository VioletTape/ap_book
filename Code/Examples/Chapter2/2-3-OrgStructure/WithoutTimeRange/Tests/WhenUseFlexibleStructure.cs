﻿using FluentAssertions;
using NUnit.Framework;

namespace Chapter2._2_3_OrgStructure.WithoutTimeRange;

public class WhenUseFlexibleStructure {
    [Test]
    public void CanAddDepartment() {
        var organization = new Organization("acme", new OrgStructureFlexible());

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
