namespace MefContrib.Web
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Primitives;
    using System.Linq;

    public class WebScopedComposablePartDefinition : ComposablePartDefinition
    {
        private readonly ComposablePartDefinition _partDefinition;

        internal WebScopedComposablePartDefinition(ComposablePartDefinition partDefinition)
        {
            _partDefinition = partDefinition;
        }

        public override ComposablePart CreatePart()
        {
            var policy = (WebCreationPolicy)_partDefinition.ExportDefinitions.First().Metadata["CreationPolicy"];

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