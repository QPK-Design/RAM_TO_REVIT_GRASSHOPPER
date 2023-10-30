using RAM_TO_REVIT_GRASSHOPPER;
using Grasshopper.Kernel;
using RAMDATAACCESSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM_TO_REVIT_GRASSHOPPER
{
    public class GET_FLOOR_TYPE_COUNT : GH_Component
    {

        public GET_FLOOR_TYPE_COUNT() : base("GET_FLOOR_TYPE_COUNT", "GFTC", "Get floor type count", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("C2D7586C-266F-40B4-B4A8-E7510FA67996"); }
        }
        public static GET_FLOOR_TYPE_COUNT Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM file path", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("FloorTypeCount", "C", "Number of floor types in model", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);


            //OPEN
            string FileName = null;
            if (!DA.GetData("FileName", ref FileName)) {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");


            IFloorTypes My_floortypes = IModel.GetFloorTypes();

            int My_floortype_count = My_floortypes.GetCount();
            DA.SetData("FloorTypeCount", My_floortype_count);

            //CLOSE
            IDBI.CloseDatabase();
        }
    }

    public class GET_FLOOR_TYPE_IDS : GH_Component
    {

        public GET_FLOOR_TYPE_IDS() : base("GET_FLOOR_TYPE_IDS", "GFTIDs", "Get the floor type Identifiers", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("03EA8647-7021-459D-AFC8-DD61FAF07D79"); }
        }
        public static GET_FLOOR_TYPE_IDS Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM file path", GH_ParamAccess.item);
            pManager.AddNumberParameter("TotalNumOfFlrTypeInListFormat", "TNFT", "List of floor types", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("FloorTypeID", "FTID", "Floor Type ID", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);


            //OPEN

            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }

            int TotalNumOfFlrTypeInListFormat = 0;
            if (!DA.GetData("TotalNumOfFlrTypeInListFormat", ref TotalNumOfFlrTypeInListFormat)) 
            {
                return;
            } 
            if (TotalNumOfFlrTypeInListFormat == 0)
            {
                return;
            }

            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();

            IFloorType My_floortype = My_floortypes.GetAt(TotalNumOfFlrTypeInListFormat);
            int My_FloorType_ID = My_floortype.lUID;
            DA.SetData("FloorTypeID", My_FloorType_ID);
            //  
            IDBI.CloseDatabase();
        }
    }


    public class SET_FLOOR_TYPE : GH_Component
    {

        public SET_FLOOR_TYPE() : base("SET_FLOOR_TYPE", "SFT", "Set Floor Type", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("3EE55B6E-4D64-4359-946B-1CAFC86C6187"); }
        }
        public static SET_FLOOR_TYPE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM File Path", GH_ParamAccess.item);
            pManager.AddTextParameter("FloorTypeName", "FTN", "Floor Type Name", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("FloorTypeID", "FTID", "Floor Type ID", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);

            //OPEN
            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }

            string FloorTypeName = null;
            if (!DA.GetData("FloorTypeName", ref FloorTypeName))
            {
                return;
            }
            if (FloorTypeName == null || FloorTypeName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_New_floortype = My_floortypes.Add(FloorTypeName);
            int MyFlrTypeID = My_New_floortype.lUID;
            DA.SetData("FloorTypeID", MyFlrTypeID);

            //CLOSE
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();

        }
    }

    public class GET_STORY_COUNT : GH_Component
    {

        public GET_STORY_COUNT() : base("GET_STORY_COUNT", "GSC", "Get Story Count", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("FF24E6AA-6701-4365-BE20-074DAC1EAD1D"); }
        }
        public static GET_FLOOR_TYPE_COUNT Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM File Path", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("My_story_count", "MSC", "My story count", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);

            //OPEN
            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            DA.SetData("My_story_count", My_story_count);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_COL_CL : GH_Component
    {

        public GET_RAM_COL_CL() : base("GET_STORY_COUNT", "GSC", "Get Story Count", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("DC579175-5B31-4E92-B8AB-0F1D2B7D8ED3"); }
        }
        public static GET_RAM_COL_CL Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();
            SCoordinate P1 = new SCoordinate();
            SCoordinate P2 = new SCoordinate();
            List<Autodesk.DesignScript.Geometry.Line> ListLine = new List<Autodesk.DesignScript.Geometry.Line>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                My_Story.GetColumns().GetAt(i).GetEndCoordinates(ref P1, ref P2);
                double P1x = P1.dXLoc;
                double P1y = P1.dYLoc;
                double P1z = P1.dZLoc;
                double P2x = P2.dXLoc;
                double P2y = P2.dYLoc;
                double P2z = P2.dZLoc;
                Autodesk.DesignScript.Geometry.Point PD1 =
                    Autodesk.DesignScript.Geometry.Point.ByCoordinates(P1x, P1y, P1z);
                Autodesk.DesignScript.Geometry.Point PD2 =
                    Autodesk.DesignScript.Geometry.Point.ByCoordinates(P2x, P2y, P2z);
                Autodesk.DesignScript.Geometry.Line Dline =
                    Autodesk.DesignScript.Geometry.Line.ByStartPointEndPoint(PD1, PD2);
                ListLine.Add(Dline);
            }
            DA.SetData("ListLine", ListLine);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_COL_SIZE : GH_Component
    {

        public GET_RAM_COL_SIZE() : base("GET_RAM_COL_SIZE", "GRCS", "Get RAM Column Size", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_RAM_COL_SIZE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();

            List<string> ListLine = new List<string>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                string My_Column_Size = My_Story.GetColumns().GetAt(i).strSectionLabel;
                ListLine.Add(My_Column_Size);
            }
            DA.SetData("ListLine", ListLine);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_COL_ID : GH_Component
    {

        public GET_RAM_COL_ID() : base("GET_RAM_COL_ID", "GRCId", "Get RAM Column ID", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_RAM_COL_ID Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();

            List<int> ListLine = new List<int>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                int My_Column_ID = My_Story.GetColumns().GetAt(i).lUID;
                ListLine.Add(My_Column_ID);
            }
            DA.SetData("ListLine", ListLine);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class  : GH_Component
    {

        public () : base(, , , "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {

        }
    }
}
