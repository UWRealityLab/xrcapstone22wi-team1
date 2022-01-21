import { Box } from "@mui/material";
import { shadows } from "@mui/system";

const Product = () => {
    return (
        <Box sx={{ boxShadow: 3 }}>
            <iframe
                title="Product Requirement Document"
                width="100%"
                height="1000px"
                src="https://docs.google.com/document/d/e/2PACX-1vS7pKeF9ydCgp8NlctNHDW3SQct1teDiuxWZ8uTC7uVV8SeFYdZtqjJp4k1Dp4MDXcN1MMXGW5Jmilw/pub?embedded=true"
            ></iframe>
        </Box>
    );
};

export default Product;
