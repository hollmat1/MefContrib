namespace MefContrib.Web
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Primitives;
    using System.Linq;

    /// <summary>
    /// Represents a composable part definition which describe and enable a the creation of web-scoped composable
    /// parts.
    /// </summary>
    public class WebScopedComposablePartDefinition : ComposablePartDefinition
    {
        private readonly ComposablePartDefinition _partDefinition;

        internal WebScopedComposablePartDefinition(ComposablePartDefinition partDefinition)
        {
            _partDefinition = partDefinition;
        }

        public override ComposablePart CreatePart()
        {
            var policy = (WebCreationPolicy)_partDefinition.ExportDefinitions.First().Metadata["WebCreationPolicy"];

            if (policy == WebCreationPolicy.Request)
                return new WebRequestScopedComposablePart(_partDefinition.CreatePart());
            else
                return new WebSessionScopedComposablePart(_partDefinition.CreatePart());
        }

        public override IEnumerable<ExportDefinition> ExportDefinitions
        {
            get { return _partDefinition.ExportDefinitions; }
        }

        public override IEnumerable<ImportDefinition> ImportDefinitions
        {
            get { return _partDefinition.ImportDefinitions; }
        }
    }
}