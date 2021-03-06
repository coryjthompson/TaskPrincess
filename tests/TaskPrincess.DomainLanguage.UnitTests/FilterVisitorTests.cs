﻿using Xunit;
using TaskPrincess.DomainLanguage;
using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using TaskPrincess.DomainLanguage.Antlr;
using TaskPrincess.DomainLanguage.Parser;
using TaskPrincess.DomainLanguage.Parser.Models;
using TaskPrincess.DomainLanguage.Parser.Behaviors;
using TaskPrincess.DomainLanguage.Parser.Interfaces;

namespace TaskPrincess.DomainLanguageTests
{
    public class FilterVisitorTests
    {
        private readonly MockItem _adventureProject = new MockItem() { Uuid = Guid.Parse("7688bae9-4e72-4630-a553-a3b0d9ffb3bb"), Id = 5, Project = "adventure", Due = DateTime.UtcNow };
        private readonly MockItem _castleProject = new MockItem() { Uuid = Guid.Parse("e7be5c17-4f4e-45f4-af4b-bd87a9ad9d87"), Id = 10, Project = "castle", Due = DateTime.UtcNow };

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

        [Fact]
        public void TestQuery_BinaryAndOperator()
        {
            var query = BuildQuery("project:castle AND id:5");
            Assert.False(query.Invoke(_adventureProject));
            Assert.False(query.Invoke(_castleProject));

            var query2 = BuildQuery("project:castle and id:10");
            Assert.False(query2.Invoke(_adventureProject));
            Assert.True(query2.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_BinaryImpliedAndOperator()
        {
            var query = BuildQuery("project:castle id:10");
            Assert.False(query.Invoke(_adventureProject));
            Assert.True(query.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_BinaryOrOperator()
        {
            var query = BuildQuery("project:castle OR id:5");
            Assert.True(query.Invoke(_adventureProject));
            Assert.True(query.Invoke(_castleProject));

            var query2 = BuildQuery("project:nothing or id:10");
            Assert.False(query2.Invoke(_adventureProject));
            Assert.True(query2.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_MultipleBinaryOperators()
        {
            var query = BuildQuery("project:castle OR id:5 AND project:adventure");
            Assert.True(query.Invoke(_adventureProject));
            Assert.False(query.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_ParenthesesBinaryOperators()
        {

            var query = BuildQuery("project:castle OR (id:10 AND project:adventure)");
            Assert.False(query.Invoke(_adventureProject));
            Assert.True(query.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_BinaryXorOperator()
        {
            var query = BuildQuery("project:castle XOR id:5");
            Assert.True(query.Invoke(_adventureProject));
            Assert.True(query.Invoke(_castleProject));

            var query2 = BuildQuery("project:castle xor id:10");
            Assert.False(query2.Invoke(_adventureProject));
            Assert.False(query2.Invoke(_castleProject));
        }

        [Fact]
        public void TestQuery_DateOperator()
        {
            var query = BuildQuery("due.after:socw");
            Assert.True(query.Invoke(_adventureProject));
        }

        private Func<MockItem, bool> BuildQuery(string text)
        {
            var inputStream = new AntlrInputStream(text);
            var filterLexer = new FilterLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(filterLexer);
            var filterParser = new FilterParser(commonTokenStream);
            var context = filterParser.query();
            var weekParser = new WeekDatesBehavior();
            var dateParser = new DateParser(new List<IDateParserBehavior>() { weekParser }, new DateParserConfig());
            var visitor = new FilterVisitor<MockItem>(dateParser);
            var expression = visitor.Visit(context);
            return expression.Compile();
        }

    }

    public class MockItem
    {
        public string Project { get; set; }
        public Guid Uuid { get; set; }
        public int Id { get; set; }
        public DateTime Due { get; set; }
    }
}
