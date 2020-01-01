﻿using System;
using System.Collections.Generic;
using DataWarehouseAutomation;

namespace Virtual_Data_Warehouse.Classes
{
    /// <summary>
    /// The parent object containing the list of source-to-target mappings. This is the highest level and contains the list of mappings (as individual objects
    /// but also the parameters inherited from TEAM and VEDW.
    /// </summary>
    class DataObjectMappingList
    {
        // Generic interface definitions
        public List<DataObjectMapping> dataObjectMapping { get; set; }

        // TEAM and VDW specific details
        public MetadataConfiguration metadataConfiguration { get; set; }
        public VedwSpecificMetadata vedwSpecificMetadata { get; set; }
    }

    /// <summary>
    /// The mapping between a source and target data set / table / file.
    /// </summary>
    class DataObjectMapping
    {
        public string dataObjectMappingName { get; set; }
        public string dataObjectMappingClassification { get; set; }
        public Boolean enabled { get; set; }

        public string sourceTable { get; set; }
        //public DataObject sourceDataObject { get; set; }
        public string targetTable { get; set; }
        //public DataObject targetDataObject { get; set; }

        public string lookupTable { get; set; }
        public string targetTableHashKey { get; set; }

        public List<BusinessKey> businessKey { get; set; }
        public string filterCriterion { get; set; }
        public List<ColumnMapping> columnMapping { get; set; }
    }

    class DataObject
    {
        public string dataObjectName { get; set; }
    }

    /// <summary>
    /// A Business Key, which consists of one or more components (column mappings) and has its own surrogate key.
    /// </summary>
    class BusinessKey
    {
        public List<ColumnMapping> businessKeyComponentMapping { get; set; }
        public string surrogateKey { get; set; }
    }

    /// <summary>
    /// The individual column-to-column mapping
    /// </summary>
    class ColumnMapping
    {
        public Column sourceColumn { get; set; }
        public Column targetColumn { get; set; }
    }

    ///// <summary>
    ///// And individual column
    ///// </summary>
    //class Column
    //{
    //    public string columnName { get; set; }
    //    public string columnType { get; set; }
    //}

    class VedwSpecificMetadata
    {
        public string selectedDataObject { get; set; }
        public DateTime generationDateTime { get; } = DateTime.Now;
    }

    /// <summary>
    /// The parameters that have been inherited from TEAM or are set in VEDW, passed as properties of the metadata.
    /// </summary>
    class MetadataConfiguration
    {
        // Databases
        public string sourceDatabaseName { get; } = FormBase.TeamConfigurationSettings.SourceDatabaseName;
        public string sourceDatabaseConnection { get; } = FormBase.TeamConfigurationSettings.ConnectionStringSource;
        public string stagingAreaDatabaseName { get; } = FormBase.TeamConfigurationSettings.StagingDatabaseName;
        public string stagingAreaDatabaseConnection { get; } = FormBase.TeamConfigurationSettings.ConnectionStringSource;
        public string persistentStagingDatabaseName { get; } = FormBase.TeamConfigurationSettings.PsaDatabaseName;
        public string persistentStagingDatabaseConnection { get; } = FormBase.TeamConfigurationSettings.ConnectionStringSource;
        public string persistentStagingSchemaName { get; } = FormBase.TeamConfigurationSettings.SchemaName;
        public string integrationDatabaseName { get; } = FormBase.TeamConfigurationSettings.IntegrationDatabaseName;
        public string integrationDatabaseConnection { get; } = FormBase.TeamConfigurationSettings.ConnectionStringSource;
        public string presentationDatabaseName { get; } = FormBase.TeamConfigurationSettings.PresentationDatabaseName;
        public string presentationDatabaseConnection { get; } = FormBase.TeamConfigurationSettings.ConnectionStringSource;
        public string vedwSchemaName { get; } = FormBase.VedwConfigurationSettings.VedwSchema;

        // Attributes
        public string changeDataCaptureAttribute { get; set; } = FormBase.TeamConfigurationSettings.ChangeDataCaptureAttribute;
        public string recordSourceAttribute { get; } = FormBase.TeamConfigurationSettings.RecordSourceAttribute;
        public string loadDateTimeAttribute { get; } = FormBase.TeamConfigurationSettings.LoadDateTimeAttribute;
        public string eventDateTimeAttribute { get; set; } = FormBase.TeamConfigurationSettings.EventDateTimeAttribute;
        public string recordChecksumAttribute { get; set; } = FormBase.TeamConfigurationSettings.RecordChecksumAttribute;
        public string etlProcessAttribute { get; } = FormBase.TeamConfigurationSettings.EtlProcessAttribute;
        public string sourceRowIdAttribute { get; } = FormBase.TeamConfigurationSettings.RowIdAttribute;
    }

}
