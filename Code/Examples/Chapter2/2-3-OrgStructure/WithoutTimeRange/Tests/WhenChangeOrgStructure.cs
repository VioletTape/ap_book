using FluentAssertions;
using NUnit.Framework;

namespace Chapter2._2_3_OrgStructure.WithoutTimeRange;

public class WhenChangeOrgStructure {
    [Test]
    public void ShouldApplyNewStructure() {
        var organization = new Organization("acme", new OrgStructureStrict());

        // pre assert
        organization.Add(new Division("b"));
        organization.SubUnits.Count().Should().Be(0);

        // act 
        organization.SetStructure(new OrgStructureFlexible());
        organization.Add(new Division("b"));

        // assert
        organization.SubUnits.Count().Should().Be(1);
    }
}
