import { Grid, Container, Typography } from "@mui/material";
import "./index.css";

interface IProps {
    title: string;
}

const Banner = ({ title }: IProps) => {
    return (
        <div id="banner">
            <div className="overlay"></div>
            <Container>
                <Grid container>
                    <Grid item md={10} lg={8} sx={{ textAlign: "center" }}>
                        <Typography variant="h1" sx={{ fontWeight: 700 }}>
                            {title}
                        </Typography>
                    </Grid>
                </Grid>
            </Container>
        </div>
    );
};

export default Banner;
