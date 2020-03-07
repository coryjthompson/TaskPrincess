using TaskPrincess.Infrastructure.Serilization;
using Xunit;

namespace TaskPrincess.InfrastructureTest.Serilization
{
    public class TaskWarriorNamingPolicyTests
    {
        [Fact]
        public void TestConvertName_Id()
        {
            var policy = new TaskWarriorNamingPolicy();

            var result = policy.ConvertName("Id");

            Assert.Equal("uuid", result);
        }

        [Fact]
        public void TestConvertName_Created()
        {
            var policy = new TaskWarriorNamingPolicy();

            var result = policy.ConvertName("Created");

            Assert.Equal("entry", result);
        }

        [Fact]
        public void TestConvertName_Auto()
        {
            var policy = new TaskWarriorNamingPolicy();

            var descriptionResults = policy.ConvertName("Description");
            var statusResults = policy.ConvertName("Status");
            var projectResults = policy.ConvertName("Project");
            var tagsResults = policy.ConvertName("Tags");
            var modifiedResults = policy.ConvertName("Modified");

            Assert.Equal("description", descriptionResults);
            Assert.Equal("status", statusResults);
            Assert.Equal("project", projectResults);
            Assert.Equal("tags", tagsResults);
            Assert.Equal("modified", modifiedResults);
        }
    }
}
