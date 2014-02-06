﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Confuser.Core.Services;

namespace Confuser.Core
{
    /// <summary>
    /// Core component of Confuser.
    /// </summary>
    public class CoreComponent : ConfuserComponent
    {
        ConfuserParameters parameters;
        Marker marker;
        /// <summary>
        /// Initializes a new instance of the <see cref="CoreComponent" /> class.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="marker">The marker.</param>
        internal CoreComponent(ConfuserParameters parameters, Marker marker)
        {
            this.parameters = parameters;
            this.marker = marker;
        }

        /// <summary>
        /// The service ID of RNG
        /// </summary>
        public const string _RandomServiceId = "Confuser.Random";

        /// <summary>
        /// The service ID of Marker
        /// </summary>
        public const string _MarkerServiceId = "Confuser.Marker";

        /// <inheritdoc/>
        protected internal override void Initialize(ConfuserContext context)
        {
            context.Registry.RegisterService(_RandomServiceId, typeof(IRandomService), new RandomService(parameters.Project.Seed));
            context.Registry.RegisterService(_MarkerServiceId, typeof(IMarkerService), new MarkerService(context, marker));
        }

        /// <inheritdoc/>
        protected internal override void PopulatePipeline(ProtectionPipeline pipeline)
        {
            //
        }

        /// <inheritdoc/>
        public override string Name
        {
            get { return "Confuser Core"; }
        }

        /// <inheritdoc/>
        public override string Description
        {
            get { return "Initialization of Confuser core services."; }
        }

        /// <inheritdoc/>
        public override string Id
        {
            get { return "Confuser.Core"; }
        }

        /// <inheritdoc/>
        public override string FullId
        {
            get { return "Confuser.Core"; }
        }
    }
}
