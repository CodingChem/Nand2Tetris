namespace HackAssembler.Library.Components.Interfaces
{
    /// <summary>
    /// The <c>IAssembler</c> assembles hack assembly files to hack binary files.
    /// </summary>
    public interface IAssembler
    {
        /// <summary>
        /// Produces a Task to assemble the given hack assembly file to a hack machine code file(.hack).
        /// </summary>
        /// <param name="inputFile">The file to be assembled.</param>
        /// <returns>a <c>Task</c> to write the output file.</returns>
        Task Assemble(string inputFile);
    }
}