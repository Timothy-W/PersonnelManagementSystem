<template>
  <form @submit="onSubmit" class="add-form">
    <div class="form-control">
      <label>First Name</label>
      <input
        type="text"
        v-model="firstName"
        name="text"
        placeholder="Add First Name"
      />
    </div>

    <div class="form-control">
      <label>Last Name</label>
      <input
        type="text"
        v-model="lastName"
        name="text"
        placeholder="Add Last Name"
      />
    </div>

    <div class="form-control">
      <label>Rank</label>
      <input type="text" v-model="rank" name="text" placeholder="Add Rank" />
    </div>
    <input type="submit" value="Update" class="btn btn-block" />
  </form>
</template>

<script>
export default {
  name: "EditPersonnelForm",
  props: {
    personToUpdate: Object,
  },
  data() {
    return {
      id: this.personToUpdate.id,
      firstName: this.personToUpdate.firstName,
      lastName: this.personToUpdate.lastName,
      rank: this.personToUpdate.rank,
    };
  },
  emits: ["add-personnel", "update-person"],
  methods: {
    onSubmit(e) {
      e.preventDefault();

      if (!this.firstName || !this.lastName || !this.rank) {
        alert("Please fill out all information");
      }

      const updatedPerson = {
        id: this.id,
        firstName: this.firstName,
        lastName: this.lastName,
        rank: this.rank,
      };

      this.$emit("update-person", updatedPerson);

      this.firstName = "";
      this.lastName = "";
      this.rank = "";
    },
  },
};
</script>


<style scoped>
.add-form {
  margin-bottom: 40px;
}
.form-control {
  margin: 20px 0;
}
.form-control label {
  display: block;
}
.form-control input {
  width: 100%;
  height: 40px;
  margin: 5px;
  padding: 3px 7px;
  font-size: 17px;
}
.form-control-check {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
.form-control-check label {
  flex: 1;
}
.form-control-check input {
  flex: 2;
  height: 20px;
}
</style>