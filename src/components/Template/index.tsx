import { ReactNode } from "react";
import { Box, Container } from "@mui/material";
import Banner from "../../components/Banner";

interface IProps {
    title: string;
    element: ReactNode;
}

const Template = ({ title, element }: IProps) => {
    return (
        <Box sx={{ marginBottom: "4em" }}>
            <Banner title={title} />
            <Container maxWidth="lg">{element}</Container>
        </Box>
    );
};

export default Template;
