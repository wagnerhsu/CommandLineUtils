// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Xunit;

namespace McMaster.Extensions.CommandLineUtils.Tests
{
    public class ParentPropertyConventionTests
    {
        [Subcommand(typeof(AddCommand))]
        private class Program
        {
            public object? Subcommand { get; set; }
        }

        private class AddCommand
        {
            public object? Parent { get; }
        }

        [Fact]
        public void BindsToParentProperty()
        {
            var app = new CommandLineApplication<Program>();
            app.Conventions.UseDefaultConventions();
            var result = app.Parse("add");
            var add = Assert.IsType<CommandLineApplication<AddCommand>>(result.SelectedCommand);
            Assert.IsType<Program>(add.Model.Parent);
        }
    }
}
