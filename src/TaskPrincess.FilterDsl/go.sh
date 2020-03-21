export CLASSPATH=".:/usr/local/lib/antlr-4.7.1-complete.jar:$CLASSPATH"
alias antlr4='java -Xmx500M -cp "/usr/local/lib/antlr-4.7.1-complete.jar:$CLASSPATH" org.antlr.v4.Tool'
alias grun='java -Xmx500M -cp "/usr/local/lib/antlr-4.7.1-complete.jar:$CLASSPATH" org.antlr.v4.gui.TestRig'

antlr4 -Dlanguage=CSharp -o Antlr -package TaskPrincess.FilterDsl.Antlr -no-listener -visitor Filter.g4
mv Antlr/FilterVisitor.cs Antlr/IFilterVisitor.cs
rm -rf ./Antl/*.tokens
rm -rf ./Antl/*.interp
