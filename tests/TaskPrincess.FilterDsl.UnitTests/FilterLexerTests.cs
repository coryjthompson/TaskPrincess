using Xunit;
using TaskPrincess.FilterDsl;
using System;
using Antlr4.Runtime;
using TaskPrincess.FilterDsl.Antlr;

namespace TaskPrincess.FilterDslTest
{
    public class FilterLexerTests
    {
        private readonly MockItem _adventureProject = new MockItem() { Uuid = Guid.Parse("7688bae9-4e72-4630-a553-a3b0d9ffb3bb"), Id=5, Project = "adventure" };
        private readonly MockItem _castleProject = new MockItem() { Uuid = Guid.Parse("e7be5c17-4f4e-45f4-af4b-bd87a9ad9d87"), Id=10, Project = "castle" };

        [Fact]
        public void TestQuery_EqualsOnQuotedString()
        {
            var query = BuildQuery("project = \"castle\"");
            Assert.False(query.Invoke(_adventureProject));
            Assert.True(query.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_EqualsOnWord()
        {
            var query = BuildQuery("project = castle");
            Assert.False(query.Invoke(_adventureProject));
            Assert.True(query.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_NotEqualOnString()
        {
            var query = BuildQuery("project != castle");
            Assert.True(query.Invoke(_adventureProject));
            Assert.False(query.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_EqualsOnAttribute()
        {
            var query = BuildQuery("project:castle");
            Assert.False(query.Invoke(_adventureProject));
            Assert.True(query.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_NotEqualsOnAttribute()
        {
            var query = BuildQuery("project.not:castle");
            Assert.True(query.Invoke(_adventureProject));
            Assert.False(query.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_EqualsOnUuid()
        {
            var query = BuildQuery("uuid = 7688bae9-4e72-4630-a553-a3b0d9ffb3bb");
            Assert.True(query.Invoke(_adventureProject));
            Assert.False(query.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_GetByUuid()
        {
            var query = BuildQuery("7688bae9-4e72-4630-a553-a3b0d9ffb3bb");
            Assert.True(query.Invoke(_adventureProject));
            Assert.False(query.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_EqualsOnId()
        {
            var query = BuildQuery("id = 5");
            Assert.True(query.Invoke(_adventureProject));
            Assert.False(query.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_GetById()
        {
            var query = BuildQuery("5");
            Assert.True(query.Invoke(_adventureProject));
            Assert.False(query.Invoke(_castleProject));
        }

        private Func<MockItem, bool> BuildQuery(string text)
        {
            var inputStream = new AntlrInputStream(text);
            var filterLexer = new FilterLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(filterLexer);
            var filterParser = new FilterParser(commonTokenStream);
            var context = filterParser.query();
            var visitor = new FilterVisitor<MockItem>();
            var expression = visitor.Visit(context);
            return expression.Compile();
        }

    }

    public class MockItem
    {
        public string Project { get; set; }
        public Guid Uuid { get; set; }
        public int Id {get; set;}
    }
}
