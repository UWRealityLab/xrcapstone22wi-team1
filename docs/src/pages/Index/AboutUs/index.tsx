import {
    Container,
    Typography,
    Grid,
    Card,
    CardMedia,
    CardContent,
    CardActions,
    Button,
} from "@mui/material";

const AboutUs = () => {
    return (
        <Container maxWidth="lg">
            <Typography
                variant="h3"
                align="center"
                sx={{ marginBottom: "1em" }}
            >
                About Us
            </Typography>
            <Grid container justifyContent="center" direction="row" spacing={2}>
                {ABOUT.map((person) => (
                    <Grid item xs={12} md={4}>
                        <Card sx={{ maxWidth: 345, margin: "auto" }}>
                            <CardMedia
                                component="img"
                                image={person.image}
                                alt={person.name}
                            />
                            <CardContent>
                                <Typography
                                    gutterBottom
                                    variant="h5"
                                    component="div"
                                >
                                    {person.name}
                                </Typography>
                                <Typography
                                    variant="body2"
                                    color="text.secondary"
                                >
                                    {person.description}
                                </Typography>
                            </CardContent>
                            <CardActions>
                                <a
                                    href={person.link}
                                    target="_blank"
                                    rel="noreferrer"
                                >
                                    <Button size="small">Learn More</Button>
                                </a>
                            </CardActions>
                        </Card>
                    </Grid>
                ))}
            </Grid>
        </Container>
    );
};

const ABOUT = [
    {
        name: "Jolin Tsai",
        image: "static/images/AboutUs/jolin.jpg",
        description: "Hi, I am an undergrad CS student in UW",
        link: "https://linkedin.com",
    },
    {
        name: "Peter Chan",
        image: "static/images/AboutUs/peter.jpg",
        description: "Hi, I am an undergrad CS student in UW",
        link: "https://linkedin.com",
    },
    {
        name: "Justin Huang",
        image: "static/images/AboutUs/justin.jpg",
        description: "Hi, I am an undergrad CS student in UW",
        link: "https://linkedin.com",
    },
];

export default AboutUs;
