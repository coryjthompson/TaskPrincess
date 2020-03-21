using System;
using TaskPrincess.Infrastructure.Serilization;
using Xunit;

namespace TaskPrincess.InfrastructureTest.Serilization
{
    public class TaskWarriorSerializerTest
    {
        [Fact]
        public void TestDeserialize_MinimalItem()
        {
            // This item is the most basic item when running tasks add item
            var serializedTodo = "{\"description\":\"Create an ice castle\",\"entry\":\"20200307T011102Z\",\"modified\":\"20200307T011102Z\",\"status\":\"pending\",\"uuid\":\"c8195128-b0ad-4ea1-bfe3-b9f78884caa9\"}";

            var serializer = new TaskWarriorSerializer();
            var results = serializer.Deserialize(serializedTodo);

            Assert.Equal("Create an ice castle", results.Description);
            Assert.Equal(DateTime.Parse("2020-03-07 01:11Z"), results.Created.Value, TimeSpan.FromMinutes(1));
            Assert.Equal(DateTime.Parse("2020-03-07 01:11Z"), results.Modified.Value, TimeSpan.FromMinutes(1));
            Assert.Equal("pending", results.Status);
            Assert.Equal(Guid.Parse("c8195128-b0ad-4ea1-bfe3-b9f78884caa9"), results.Id);
        }

        [Fact]
        public void TestDeserialize_ItemWithProject()
        {
            var serializedTodo = "{\"description\":\"Meet Olaf\",\"entry\":\"20200307T014255Z\",\"modified\":\"20200307T014255Z\",\"project\":\"make friends\",\"status\":\"pending\",\"uuid\":\"350c9222-32c3-48b9-b4c9-2ad3c0c9c7d3\"}";

            var serializer = new TaskWarriorSerializer();
            var results = serializer.Deserialize(serializedTodo);

            Assert.Equal("Meet Olaf", results.Description);
            Assert.Equal(DateTime.Parse("2020-03-07 01:42Z"), results.Created.Value, TimeSpan.FromMinutes(1));
            Assert.Equal(DateTime.Parse("2020-03-07 01:42Z"), results.Modified.Value, TimeSpan.FromMinutes(1));
            Assert.Equal("pending", results.Status);
            Assert.Equal(Guid.Parse("350c9222-32c3-48b9-b4c9-2ad3c0c9c7d3"), results.Id);
            Assert.Equal("make friends", results.Project);
        }

        [Fact]
        public void TestDeserialize_ItemWithTags()
        {
            var serializedTodo = "{\"description\":\"Adventure back to Arendelle\",\"entry\":\"20200307T015923Z\",\"modified\":\"20200307T015923Z\",\"project\":\"save arendelle\",\"status\":\"pending\",\"tags\":[\"next\",\"hero\",\"high_energy\"],\"uuid\":\"582f7f46-1a6c-4959-b442-5a80d72d8af3\"}";

            var serializer = new TaskWarriorSerializer();
            var results = serializer.Deserialize(serializedTodo);

            Assert.Equal("Adventure back to Arendelle", results.Description);
            Assert.Equal(DateTime.Parse("2020-03-07 01:59Z"), results.Created.Value, TimeSpan.FromMinutes(1));
            Assert.Equal(DateTime.Parse("2020-03-07 01:59Z"), results.Modified.Value, TimeSpan.FromMinutes(1));
            Assert.Equal("pending", results.Status);
            Assert.Equal(Guid.Parse("582f7f46-1a6c-4959-b442-5a80d72d8af3"), results.Id);
            Assert.Equal("save arendelle", results.Project);
            Assert.Equal(new string[] { "next", "hero", "high_energy" }, results.Tags);
        }

        [Fact]
        public void TestDeserialize_ItemWithDueDate()
        {
            var serializedTodo = "{\"description\":\"Buy Anna a 200th Birthday Present\",\"due\":\"20210620T140000Z\",\"entry\":\"20200307T024712Z\",\"modified\":\"20200307T024712Z\",\"status\":\"pending\",\"uuid\":\"aceb10c3-e746-4159-9c76-23c7aa9a6781\"}";

            var serializer = new TaskWarriorSerializer();
            var results = serializer.Deserialize(serializedTodo);

            Assert.Equal("Buy Anna a 200th Birthday Present", results.Description);
            Assert.Equal(DateTime.Parse("2020-03-07 02:47Z"), results.Created.Value, TimeSpan.FromMinutes(1));
            Assert.Equal(DateTime.Parse("2020-03-07 02:47Z"), results.Modified.Value, TimeSpan.FromMinutes(1));
            Assert.Equal("pending", results.Status);
            Assert.Equal(Guid.Parse("aceb10c3-e746-4159-9c76-23c7aa9a6781"), results.Id);
            Assert.Equal(DateTime.Parse("2021-06-20 14:00Z"), results.Due.Value, TimeSpan.FromMinutes(1));
        }

        [Fact]
        public void TestDeserialize_ItemWithPriority()
        {
            var serializedTodo = "{\"description\":\"Save the melting Olaf\",\"entry\":\"20200307T025837Z\",\"modified\":\"20200307T025837Z\",\"priority\":\"H\",\"status\":\"pending\",\"uuid\":\"a95f8e13-959d-445d-ba53-e83edbf2061d\"}";

            var serializer = new TaskWarriorSerializer();
            var results = serializer.Deserialize(serializedTodo);

            Assert.Equal("Save the melting Olaf", results.Description);
            Assert.Equal(DateTime.Parse("2020-03-07 02:58Z"), results.Created.Value, TimeSpan.FromMinutes(1));
            Assert.Equal(DateTime.Parse("2020-03-07 02:58Z"), results.Modified.Value, TimeSpan.FromMinutes(1));
            Assert.Equal("pending", results.Status);
            Assert.Equal(Guid.Parse("a95f8e13-959d-445d-ba53-e83edbf2061d"), results.Id);
            Assert.Equal("H", results.Priority);
        }

        [Fact]
        public void TestDeserialize_FileInWrongFormat()
        {
            //TODO:
            var serializedTodo = "\"description\":\"Meet Olaf\",\"entry\":\"20200307T014255Z\",\"modified\":\"20200307T014255Z\",\"project\":\"make friends\",\"status\":\"pending\",\"uuid\":\"350c9222-32c3-48b9-b4c9-2ad3c0c9c7d3\"";

            var serializer = new TaskWarriorSerializer();
//            var results = serializer.Deserialize(serializedTodo);

//#            Assert.Equal("Meet Olaf", results.Description);
        }
    }
}
